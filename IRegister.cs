using System;

namespace vmnet
{
    public interface IRegister
        : HasName
    {
        int Value { get; }

        IRegister UpdateValue(IOperation<int> operation);
    }
}