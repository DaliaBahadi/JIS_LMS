﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Borrowing")]
    public partial class Borrowing
    {
        [Key]
        public int BorrowingId { get; set; }
        [Required(ErrorMessage = "The Borrowing Date and Time field is required ")]
        public DateTime? BorrowingDateTime { get; set; }
        [Required(ErrorMessage = "The Due Date and Time field is required ")]
        public DateTime? DueDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public DateTime? RenwalDateTime { get; set; }
        [Required(ErrorMessage = "The Signature File field is required ")]
        public string SignatureFile { get; set; }
        public string Remark { get; set; }
        public int LibraryMaterialId { get; set; }
        public int PatronId { get; set; }

        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.Borrowings))]
        public virtual Library_Material LibraryMaterial { get; set; }
        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Borrowings")]
        public virtual Patron Patron { get; set; }
    }
}
