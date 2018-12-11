using System;

namespace vmnet
{
    public class MachineOperation
        : Operation<IMachineState>
    {
        public MachineOperation(Func<IMachineState, IMachineState> function)
            : base(function)
        {}
    }
}