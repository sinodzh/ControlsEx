using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlsEx
{
    /// <summary>
    /// 正在改变EventArgs
    /// </summary>
    public class ChangingEventArgs : CancelEventArgs
    {
        private object newValue;
        private object oldValue;

        /// <summary>
        /// 正在改变EventArgs
        /// </summary>
        /// <param name="oldValue">原值</param>
        /// <param name="newValue">新值</param>
        public ChangingEventArgs(object oldValue, object newValue)
            : this(oldValue, newValue, false)
        {
        }

        /// <summary>
        /// 正在改变EventArgs
        /// </summary>
        /// <param name="oldValue">原值</param>
        /// <param name="newValue">新值</param>
        /// <param name="cancel">是否取消</param>
        public ChangingEventArgs(object oldValue, object newValue, bool cancel)
            : base(cancel)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        /// <summary>
        /// 新值
        /// </summary>
        public object NewValue
        {
            get
            {
                return this.newValue;
            }
            set
            {
                this.newValue = value;
            }
        }

        /// <summary>
        /// 原值
        /// </summary>
        public object OldValue
        {
            get
            {
                return this.oldValue;
            }
        }
    }
}
