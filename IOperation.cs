using System;

namespace vmnet
{
    public interface IOperation<TState>
    {
        TState Run(TState t);
    }
}