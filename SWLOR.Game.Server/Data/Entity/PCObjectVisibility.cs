

using System;
using SWLOR.Game.Server.Data.Contracts;

namespace SWLOR.Game.Server.Data.Entity
{
    public class PCObjectVisibility: IEntity
    {
        public PCObjectVisibility()
        {
            ID = Guid.NewGuid();
        }
        [Key]
        public Guid ID { get; set; }
        public Guid PlayerID { get; set; }
        public string VisibilityObjectID { get; set; }
        public bool IsVisible { get; set; }
    }
}
