﻿namespace Repositories
{
    public class BaseEntity
    {
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public int CreatedByUser { get; set; }

        public int? UpdatedByUser { get; set; }
    }
}