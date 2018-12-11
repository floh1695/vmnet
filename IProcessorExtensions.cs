using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace vmnet
{
    public static class IProcessorExtensions
    {
        public static IProcessor AddRegisters(
            this IProcessor @this,
            ICollection<IRegister> registers) =>
            @this.AddSpecialized(
                registers,
                (processor, register) => processor.AddRegister(register));

        public static IProcessor AddMemories(
            this IProcessor @this,
            ICollection<IMemory> memories) =>
            @this.AddSpecialized(
                memories,
                (processor, memory) => processor.AddMemory(memory));

        public static IProcessor AddInstructions(
            this IProcessor @this,
            ICollection<IInstruction> instructions) =>
            @this.AddSpecialized(
                instructions,
                (processor, instruction) => processor.AddInstruction(instruction));

        private static IProcessor AddSpecialized<T>(
            this IProcessor @this,
            ICollection<T> collection,
            Func<IProcessor, T, IProcessor> operation) =>
            collection.Aggregate(@this, operation);
    }
}