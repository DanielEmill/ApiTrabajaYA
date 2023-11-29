using System;
using System.ComponentModel.DataAnnotations;

public class Empleo
{
    [Key]
    public int EmpleoId { get; set; }
    [Required(ErrorMessage = "El Nombre es requerido")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La descripción es requerida")]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "La categoría es requerida")]
    public string Categoria { get; set; }
    [Required(ErrorMessage = "La provincia es requerida")]
    public string Provincia { get; set; }
    [Display(Name = "Fecha de Publicación")]
    [Required(ErrorMessage = "La fecha de publicación es requerida")]
    public DateTime FechaDePublicacion { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "El número de contacto es requerido")]
    public string Numero { get; set; }
    [Required(ErrorMessage = "La dirección de correo es requerida")]
    [EmailAddress(ErrorMessage = "La dirección de correo no es válida")]
    public string Correo { get; set; }
    [Required(ErrorMessage = "La dirección es requerida")]
    public string Direccion { get; set; }
}