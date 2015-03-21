using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlsEx
{
    public class TextBoxEx:TextBox
    {
        #region 委托
        /// <summary>
        /// 改变中事件句柄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ChangingEventHandler(object sender, ChangingEventArgs e);
        #endregion

        #region 参数
        private Int32 _maxNum = Int32.MaxValue;//最大值
        private Int32 _minNum = Int32.MinValue;//最小值
        private ValueType _editValueType = ValueType.String;
        private static readonly object editValueChanging = new object();//EditValueChanging事件对应的Key
        #endregion

        #region Protected 参数
        /// <summary>
        /// 编制值
        /// </summary>
        protected object fEditValue = null;
        /// <summary>
        /// 编辑原始值
        /// </summary>
        protected object fOldEditValue = null; 
        #endregion

        #region 公有属性
        /// <summary>
        /// 输入的最大值
        /// </summary>
        [Description("输入的最大值")]
        public Int32 MaxNum
        {
            get { return _maxNum; }
            set { _maxNum = value; }
        }
        /// <summary>
        /// 输入的最小值
        /// </summary>
        [Description("输入的最小值")]
        public Int32 MinNum
        {
            get { return _minNum; }
            set
            {
                if (value <= 0)
                    _minNum = value;
            }
        }
        /// <summary>
        /// 输入值类型
        /// </summary>
        [Description("输入值类型")]
        public ValueType EditValueType
        {
            get { return _editValueType; }
            set
            {
                _editValueType = value;
                //设置初始值
                if (value == ValueType.Number)
                {
                    EditValue = 0;
                }
                else
                    EditValue = null;
            }
        }
     
        #endregion

        #region 事件属性
        /// <summary>
        /// <para>值改变中事件
        /// </para>
        /// </summary>
        [Description("值改变中事件"), Category("事件")]
        public event ChangingEventHandler EditValueChanging
        {
            add
            {
                base.Events.AddHandler(editValueChanging, value);
            }
            remove
            {
                base.Events.RemoveHandler(editValueChanging, value);
            }
        }  
        #endregion

        #region 私有属性
        /// <summary>
        /// 编辑值
        /// </summary>
        private object EditValue
        {
            get { return fEditValue; }
            set
            {
                if (EditValue == value) return;
                OnEditValueChanging(new ChangingEventArgs(fEditValue, value));
                this.Text = fEditValue == null ? null : fEditValue.ToString();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 编辑值正在改变事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEditValueChanging(ChangingEventArgs e)
        {
            //调用注册的事件
            ReiseEditValueChanging(e);

            if (e.Cancel)//注册的事件取消 还原值
            {
                fEditValue = e.OldValue;
                return;
            }

            switch (_editValueType)
            {
                case ValueType.Number://数值类型
                    {
                        if (e.NewValue != null && !string.IsNullOrEmpty(e.NewValue.ToString()))//非空值
                        {
                            int intNewNum = 0;
                            if (!Int32.TryParse(e.NewValue.ToString(), out intNewNum))//非数字
                            {
                                string strOp = e.NewValue.ToString();
                                //负号
                                if (ParseValueIsMinus(strOp))
                                {
                                    strOp = strOp.Replace("-", "");

                                    int tempMin = 0;
                                    if (Int32.TryParse(strOp, out tempMin))
                                    {
                                        if (tempMin > Math.Abs(MinNum + 1))
                                        {
                                            fEditValue = e.OldValue;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        fEditValue = e.OldValue;
                                        return;
                                    }
                                    strOp = "-" + strOp;
                                    fEditValue = strOp;
                                }
                                else if (strOp.Contains("-"))//多负号情况
                                {
                                    strOp = strOp.Replace("-", "");
                                    int tempMax = 0;
                                    if (Int32.TryParse(strOp, out tempMax))
                                    {
                                        if (tempMax > MaxNum)
                                        {
                                            fEditValue = e.OldValue;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        fEditValue = e.OldValue;
                                        return;
                                    }
                                    fEditValue = strOp;
                                }
                                else
                                    fEditValue = e.OldValue;//还原
                                return;
                            }
                            if (intNewNum > MaxNum
                                || intNewNum < MinNum)//不在范围里的数据
                            {
                                fEditValue = e.OldValue;
                                return;
                            }
                            //同步设置新值
                            fEditValue = e.NewValue;
                        }
                        else
                        {
                            //同步设置新值(特殊)
                            fEditValue = 0;
                        }
                    } break;
                case ValueType.String:
                    {
                        fEditValue = e.NewValue;
                    } break;
                default:
                    {
                        fEditValue = e.NewValue;
                    } break;

            }
        }

        /// <summary>
        /// 值改变后事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text != null)
                this.SelectionStart = this.Text.Length;

            if (this.Text.Equals(EditValue))
            {
                return;
            }

            base.OnTextChanged(e);
            EditValue = this.Text;
        }

        /// <summary>
        /// 调用注册的事件
        /// </summary>
        /// <param name="e"></param>
        public void ReiseEditValueChanging(ChangingEventArgs e)
        {
            ChangingEventHandler handler = (ChangingEventHandler)this.Events[editValueChanging];
            if (handler != null) handler(this, e);
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 判断字符串是否是负数
        /// </summary>
        /// <param name="strOp"></param>
        /// <returns></returns>
        private bool ParseValueIsMinus(string strOp)
        {
            bool blReturn = false;

            int index = strOp.IndexOf('-');
            if (index >= 0)
            {
                index = strOp.IndexOf('-', index + 1);
                if (index < 0)
                    blReturn = true;
            }
            return blReturn;
        }
        #endregion


        #region 枚举
        /// <summary>
        /// 改变值类型
        /// </summary>
        public enum ValueType
        {
            Number,
            String,
        } 
        #endregion
    }
}
