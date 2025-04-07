using UnityEngine;

namespace Ringo.AI
{
    public class FalseBoolBlackBoardDecorator : Decorator
    {
        private string _key;
        
        public FalseBoolBlackBoardDecorator(string key, Node child) : base(child)
        {
            _key = key;
        }

        public override ReturnValue Evaluate()
        {
            object value;
            
            if (!BlackBoard.TryGetData(_key, out value))
            {
                Debug.LogWarning("Black Board: " + _key + " not found");
                return ReturnValue.Failure;
            }
            
            bool boolValue = (bool) value;

            return boolValue ? ReturnValue.Failure : Child.Evaluate();
        }
    }
}