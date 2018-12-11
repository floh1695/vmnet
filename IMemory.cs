using System;

namespace vmnet
{
    public interface IMemory
        : HasName
    {
        IMemory UpdateValue(int address, IOperation<int> operation);
    }
}