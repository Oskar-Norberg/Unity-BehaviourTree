using UnityEngine;

namespace Ringo.AI
{
    public class BoolBlackBoardDecorator : Decorator
    {
        private string _key;
        
        public BoolBlackBoardDecorator(string key, Node child) : base(child)
        {
            _key = key;
        }

        public override ReturnValue Evaluate()
        {
            object value;
            
            if (!BlackBoard.TryGetData(_key, out value))
            {
                Debug.LogWarning("Black Board: " + _key + " not found");
            }
            
            bool boolValue = (bool) value;

            return boolValue ? Child.Evaluate() : ReturnValue.Failure;
        }
    }
}