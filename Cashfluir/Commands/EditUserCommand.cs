﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Commands
{
    public class EditUserCommand
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public CategoryType Type { get; set; }
    }
}