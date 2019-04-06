﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPARCIAL1.Models
{
    public enum FriendType
    {
        Conocido,
        CompañeroEstudio,
        ColegadeTrabajo,
        Amigo,
        AmigodeInfancia,
        Pariente
    }
    public class MauroHernandezFriend
    {
        [Key]
        public int FriendId { get; set; }

        [Required]
        public string FullName { get; set; }
        public string TypeFriend { get; set; }
        public string Nickname { get; set; }
        public int DateTime { get; set; }

        [Required]
        public FriendType Friend { get; set; }
    }
}