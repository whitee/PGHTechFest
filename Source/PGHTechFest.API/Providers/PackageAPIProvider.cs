using Newtonsoft.Json;
using PGHTechFest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGHTechFest.API.Providers
{
    public class PackageAPIProvider : PGHTechFest.API.Providers.APIProvider
    {
        #region Presenters
        public Task<List<Presenter>> GetPresentersAsync()
        {
            return TaskEx.Run<List<Presenter>>(() =>
            {
                return new List<Presenter>()
                {
                    Get_Hector_Correa(),
                    Get_Constantine_Aaron_Cois()
                };
            });
        }

        public List<Presenter> GetPresenters()
        {
            return new List<Presenter>()
            {
                Get_Hector_Correa(),
                Get_Constantine_Aaron_Cois()
            };
        }

        private Presenter Get_Hector_Correa()
        {
            return JsonConvert.DeserializeObject<Presenter>(_Hector_Correa);
        }
        private Presenter Get_Constantine_Aaron_Cois()
        {
            return JsonConvert.DeserializeObject<Presenter>(_Constantine_Aaron_Cois);
        }
        #endregion

        #region Sessions
        public Task<List<Session>> GetSessionsAsync()
        {
            return TaskEx.Run<List<Session>>(() =>
            {
                return new List<Session>()
                {
                    Get_Session_37(),
                    Get_Session_38()
                };
            });
        }

        public List<Session> GetSessions()
        {
            return new List<Session>()
            {
                Get_Session_37(),
                Get_Session_38()
            };
        }

        private Session Get_Session_37()
        {
            return JsonConvert.DeserializeObject<Session>(_Session_37);
        }
        private Session Get_Session_38()
        {
            return JsonConvert.DeserializeObject<Session>(_Session_38);
        }
        #endregion

        #region SampleData
        private string _Session_37 = @"{
id: ""37"",
title: ""Introduction to NoSQL databases with MongoDB"",
track: ""NoSQL Database"",
timeslot: ""2:00 - 3:00"",
timeslot_id: ""14"",
presenter: ""Hector Correa"",
presenter_id: ""21"",
description: ""You’ve heard the buzz about NoSQL databases, should you care? Are they for you? Why are they so popular these days? This session is an introduction to NoSQL databases. We’ll review what is considered a NoSQL database, what do they give us, when should we use them, when should we not use them, and what kind of NoSQL databases are out there. All examples for this talk will be given using MongoDB, an open-source, document-oriented database that is part of the NoSQL databases, but the concepts apply to most NoSQL databases."",
length: ""60"",
room: ""Ryan Room"",
notes: null,
created: null,
modified: null,
active: ""1"",
track_id: null
}";

        private string _Session_38 = @"{
id: ""38"",
title: ""Node.js Design Patterns for the Discerning Developer"",
track: ""JavaScript"",
timeslot: ""2:00 - 3:00"",
timeslot_id: ""14"",
presenter: ""Constantine Aaron Cois"",
presenter_id: ""11"",
description: ""Node.js brings JavaScript to the server-side. The up-side of this is an excellent event-based backend framework capable of lightning fast real-time interactions. The down-side is the baggage: the bulk of bad coding habits and antipatterns left over from frontend JavaScript that silently creep their way into Node.js codebases. Think plague-infected ninjas. In addition, the asynchronous nature of file and network I/O inherent to Node.js can cause its own array of headaches. Discerning developers want more. In this session, I’ll fight the good fight by presenting some high-quality design patterns for Node.js applications. I’ll bring to the table design patterns I’ve stumbled across in my own Node projects, as well as patterns observed from the classiest members of the Node community. Examples include: * Defining your models with ORMs such as Mongoose * Using Async.js to avoid callback hell * The batch pattern for asynchronous concurrent file I/O * ...and much more! Top hat and monocle encouraged, but not required."",
length: ""60"",
room: ""Room 228"",
notes: null,
created: null,
modified: null,
active: ""1"",
track_id: null
}";


        private string _Hector_Correa = @"{
id: ""21"",
name: ""Hector Correa"",
email: """",
twitter: ""hectorjcorrea"",
blog_url: ""http://hectorcorrea.com/blog"",
github_id: ""hectorcorrea"",
bio: ""Software Developer in State College, PA."",
created: null,
modified: null,
active: ""1"",
fullname: ""Hector Correa""
}";

        private string _Constantine_Aaron_Cois = @"{
id: ""11"",
name: ""Constantine Aaron Cois"",
email: """",
twitter: ""aaroncois"",
blog_url: ""www.codehenge.net/blog"",
github_id: ""cacois"",
bio: ""Aaron is a software engineer currently located in Pittsburgh, PA. He received his Ph.D. in 2007, developing algorithms and software for 3D medical image analysis. He currently leads a software development team at Carnegie Mellon University, focusing on web application development and cloud systems. Aaron is a polyglot programmer, with a keen interest in open source technologies. Some favorite technologies at the moment include Node.js, Python/Django, MongoDB, and Redis."",
created: null,
modified: null,
active: ""1"",
fullname: ""Constantine Aaron Cois""
    }";
        #endregion
    }
}
