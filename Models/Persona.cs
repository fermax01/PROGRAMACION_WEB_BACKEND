using System;
using System.Collections.Generic;

namespace ProgramacionWeb_Backend.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Curp { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Rfc { get; set; }

    public string? NombrePuesto { get; set; }
}
