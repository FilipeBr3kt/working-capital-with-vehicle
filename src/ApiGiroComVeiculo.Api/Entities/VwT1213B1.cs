using System;
using System.Collections.Generic;

namespace ApiGiroComVeiculo.Api.Entities;

public partial class VwT1213B1
{
    public int Id { get; set; }

    public int FkT1201 { get; set; }

    public int FkT1212 { get; set; }

    public string? NmProduto { get; set; }

    public string? NmMotivo { get; set; }

    public short? NrSeq { get; set; }
}
