﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldloca.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldloca_S(byte operand)
            => new Emit_Ldloca_S(operand);


        private sealed class Emit_Ldloca_S : ILStreamInstruction<byte>
        {
            public override OpCode OpCode => OpCodes.Ldloca_S;

            public Emit_Ldloca_S(byte operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldloca.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldloca.Invoke(state, Operand);
        }
    }
}
