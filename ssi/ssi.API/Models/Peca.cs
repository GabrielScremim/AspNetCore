﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ssi.API.Models;

public partial class Peca
{
    public int PecaId { get; set; }

    public DateTime DataPeca { get; set; }

    public string Descricao { get; set; }

    public decimal Valor { get; set; }

    public int FkSsiId { get; set; }

    public string FkUsuarioChapa { get; set; }

    public virtual Ssi FkSsi { get; set; }

    public virtual Usuario FkUsuarioChapaNavigation { get; set; }
}