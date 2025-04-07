using System;

namespace Ringo.AI
{
    public class PredicateDecorator : Decorator
    {
        Func<bool> _predicate;
        
        public PredicateDecorator(Func<bool> predicate, Node child) : base(child)
        {
            _predicate = predicate;
        }

        public override ReturnValue Evaluate()
        {
            return _predicate.Invoke() ? Child.Evaluate() : ReturnValue.Failure;
        }
    }
}