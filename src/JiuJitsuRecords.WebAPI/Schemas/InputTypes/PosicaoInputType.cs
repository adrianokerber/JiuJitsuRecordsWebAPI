﻿using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.WebAPI.Schemas.InputTypes
{
    public class PosicaoInputType : InputObjectGraphType<Posicao>
    {
        public PosicaoInputType()
        {
            Name = "PosicaoInput";
            Description = "PosicaoInput Type";
            Field(j => j.Nome);
        }
    }
}
