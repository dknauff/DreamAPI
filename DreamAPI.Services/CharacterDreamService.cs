using DreamAPI.Data;
using DreamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Services
{
    public class CharacterDreamService
    {
        private readonly Guid _userId;

        public CharacterDreamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacterDream(CharacterDreamCreate model)
        {
            var entity =
                new CharacterDream()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    DreamId = model.DreamId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CharacterDreams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
