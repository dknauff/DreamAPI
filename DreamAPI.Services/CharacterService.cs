using DreamAPI.Data;
using DreamAPI.Models;
using DreamAPI.Models.Character1;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Services
{
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    Relationship = model.Relationship
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == model.CharacterId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Relationship = model.Relationship;
                entity.DreamId = model.DreamId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCharacter(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == noteId && e.OwnerId == _userId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CharacterListItem
                                {
                                    CharacterId = e.CharacterId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Relationship = e.Relationship,
                                    Dreams = e.Dreams
                                }
                           );

                return query.ToArray();
            }
        }
        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == id && e.OwnerId == _userId);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        Name = entity.Name,
                        Description = entity.Description,
                        Relationship = entity.Relationship,
                        Dreams = entity.Dreams
                    };
            }
        }
    }
}
