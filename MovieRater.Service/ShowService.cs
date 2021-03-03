using MovieRater.Data;
using MovieRater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class ShowService
    {
        private readonly Guid _userId;

        public ShowService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShow(ShowCreate model)
        {
            var entity =
                new Show()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Actors = model.Actors
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shows
                        .Where(s => s.OwnerId == _userId)
                        .Select(
                            s =>
                                new ShowListItem
                                {
                                    ShowId = s.ShowId,
                                    Title = s.Title,
                                    Description = s.Description,
                                    AddedShow = s.AddedShow
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
