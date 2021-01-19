﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldloc.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldloc_S(byte operand)
            => new Emit_Ldloc_S(operand);


        private sealed class Emit_Ldloc_S : ILStreamInstruction<byte>
        {
            public override OpCode OpCode => OpCodes.Ldloc_S;

            public Emit_Ldloc_S(byte operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldloc.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldloc.Invoke(state, Operand);
        }
    }
}
