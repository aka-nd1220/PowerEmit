﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OptimizedOpCode
    {
        public static IILStreamOpCode Ldarg_Opt(ArgumentDescriptor argument)
            => new Emit_Ldarg_Opt(argument);


        private sealed class Emit_Ldarg_Opt : IILStreamOpCode
        {
            public OpCode OpCode
                => OpCodes.Ldarg;


            public int? ByteSize => null;
            public int? StackBalance => 1;


            public ArgumentDescriptor Argument { get; }


            internal Emit_Ldarg_Opt(ArgumentDescriptor argument)
            {
                Argument = argument;
            }


            public void Emit(ILGeneratorState state)
            {
                var index = state.Arguments[Argument];
                switch(index)
                {
                case 0: state.Generator.Emit(OpCodes.Ldarg_0); return;
                case 1: state.Generator.Emit(OpCodes.Ldarg_1); return;
                case 2: state.Generator.Emit(OpCodes.Ldarg_2); return;
                case 3: state.Generator.Emit(OpCodes.Ldarg_3); return;
                }
                if((ushort)index < byte.MaxValue)
                    state.Generator.Emit(OpCodes.Ldarg_S, (byte)index);
                else
                    state.Generator.Emit(OpCodes.Ldarg, index);
            }


            public int GetByteSize(ILGeneratorState state)
            {
                var index = state.Arguments[Argument];
                switch(index)
                {
                case 0: return OpCodes.Ldarg_0.GetTotalByteSize();
                case 1: return OpCodes.Ldarg_1.GetTotalByteSize();
                case 2: return OpCodes.Ldarg_2.GetTotalByteSize();
                case 3: return OpCodes.Ldarg_3.GetTotalByteSize();
                }
                return index <= byte.MaxValue
                    ? OpCodes.Ldarg_S.Size + sizeof(byte)
                    : OpCodes.Ldarg.Size + sizeof(short);
            }


            public int GetStackBalance(ILGeneratorState state) => 1;
        }
    }
}