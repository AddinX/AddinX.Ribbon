using System;

namespace AddinX.Ribbon.Contract.Command.Field
{

    public interface ICallbackField {

    }

    public class CallbackActionField<T> : ICallbackField {

        public CallbackActionField(T action) {
            this.Action = action;
        }

        public T Action { get;  }
    }

    public class CallbackFuncField<T> : ICallbackField {
        public CallbackFuncField(T function) {
            this.Function = function;
        }
        public T Function { get; set; }
    }

    public interface IActionField:ICallbackField
    {
        Action OnActionField { get; }

    }
}