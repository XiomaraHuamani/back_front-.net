﻿using System;
namespace LocalizaME.Entity
{
	public class EntityBase
	{
        public int Id { get; set; }
        public bool Status { get; set; }

        public EntityBase()
		{
            Status = true;
        }
	}
}

