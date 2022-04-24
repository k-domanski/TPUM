using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using Library.Logic.Filters;
using Timer = System.Timers.Timer;

namespace Library.Logic
{
    public class Simulation
    {
        public ILibrary library { get; }
        private Timer timer;
        private SynchronizationContext context = SynchronizationContext.Current;

        private List<Func<Random, bool>> actions;

        public bool shouldStop { get; private set; } = false;

        public Simulation(ILibrary library, float interval)
        {
            this.library = library;
            actions = new List<Func<Random, bool>> {LendBookAction, ReturnBookAction};

            timer = new Timer(interval * 1000);
            timer.Elapsed += ProgressSimulation;
            timer.AutoReset = true;
        }

        ~Simulation()
        {
            Stop();
            timer.Dispose();
        }

    public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void ProgressSimulation(object state, ElapsedEventArgs args)
        {
            context.Post((obj) =>
            {
                Random rng = new Random(args.SignalTime.Second);
                List<Func<Random, bool>> shuffle = new List<Func<Random, bool>>(actions.OrderBy(item => rng.Next()));
                foreach (Func<Random, bool> func in shuffle)
                {
                    if (func.Invoke(rng))
                    {
                        break;
                    }
                }
            }, null);
        }

        private bool LendBookAction(Random rng)
        {
            List<BookInfo> books = library.GetBooksManager().GetBooks(new BookAvailabilityFilter(true));
            List<PersonInfo> ppl = library.GetPersonsManager().GetPersons(new PassFilter<PersonInfo>());
            if (books.Count == 0 || ppl.Count == 0)
            {
                return false;
            }

            int bidx = rng.Next(0, books.Count);
            int pidx = rng.Next(0, ppl.Count);

            return library.LendBook(books[bidx].id, ppl[pidx].id);
        }

        private bool ReturnBookAction(Random rng)
        {
            List<LendingInfo> lendings = library.GetLendingsManager().GetLendings(new PassFilter<LendingInfo>());
            if (lendings.Count == 0)
            {
                return false;
            }

            int idx = rng.Next(0, lendings.Count);
            return library.ReturnBook(lendings[idx]);
        }
    }
}