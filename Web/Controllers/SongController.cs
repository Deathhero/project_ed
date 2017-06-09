using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using OurModel;
using Services.Implementation;

namespace Web.Controllers
{
    public class SongController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        static MusicDbContextProvider context = new MusicDbContextProvider();
        SongService ss = new SongService(context);

        // GET: Song
        public ActionResult Index()
        {
            var songs = db.Songs.Include(s => s.Genre);
            return View(songs.ToList());
        }

        // GET: Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = ss.GetSongById(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title");
            return View();
        }

        // POST: Song/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Duration,Appearances,IsCover,Genre,GenreId")] Song song)
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", song.GenreId);
            var songVM = new SongViewModel
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration,
                Appearances = song.Appearances,
                IsCover = song.IsCover,
                Genre = song.Genre,
                GenreId = song.GenreId
            };
            if (ModelState.IsValid)
            {
                ss.AddSong(song);
                return RedirectToAction("Index");
            }
            return View(songVM);
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
      
            Song song = ss.GetSongById(id);
            
            //song.Genre = new Genre();
            if (song == null)
            {
                return HttpNotFound();
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", song.GenreId);
            var songVM = new SongViewModel
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration,
                Appearances = song.Appearances,
                IsCover = song.IsCover,
                Genre = song.Genre,
                GenreId = song.GenreId
            };
            //List<Genre> genres = db.Genres.ToList();
            //ViewBag.Genres = genres;
            return View(songVM);
        }

        // POST: Song/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Duration,Appearances,IsCover,Genre,GenreId")] SongViewModel songVm)
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", songVm.GenreId);
            var song = new Song
            {
                Id = songVm.Id,
                Title = songVm.Title,
                Duration = songVm.Duration,
                Appearances = songVm.Appearances,
                IsCover = songVm.IsCover,
                Genre = songVm.Genre,
                GenreId = songVm.GenreId
            };
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(songVm);
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = ss.GetSongById(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = ss.GetSongById(id);
            ss.DeleteSong(song);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
