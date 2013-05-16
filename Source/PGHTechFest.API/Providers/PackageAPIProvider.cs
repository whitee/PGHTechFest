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

        #region Presentession
        public Task<List<Presentession>> GetPresentessionsAsync()
        {
            return TaskEx.Run<List<Presentession>>(() =>
            {
                return Get_Session1();
            });
        }

        public List<Presentession> GetPresentessions()
        {
            return Get_Session1();
        }


        private List<Presentession> Get_Session1()
        {
            return JsonConvert.DeserializeObject<List<Presentession>>(_Session1);
        }

        #endregion

        #region SampleData
        private string _Session1 = @"[{""id"":""51"",""time"":""9:15 - 10:15"",""title"":""\""this\"" isn't what you think it is: JavaScript for Object oriented programmers"",""track"":""JavaScript"",""description"":""JavaScript is not just for DOM manipulation: with its growing presence in browsers, on servers, and now the desktop with Windows 8, JavaScript is fast becoming the ubiquitous programming language. Regardless of your background, odds are pretty good that JavaScript will be part of your future. JavaScript has a unique feature set that can make it challenging for object oriented programmers. In this introductory session we'll discuss some of JavaScript's pitfalls and strengths. We'll take a look at strategies for developing JavaScript namespaces, classes, and objects from an object oriented perspective.  We'll also discuss some of the more popular JavaScript libraries that you'll definitely want to have in your toolbox."",""presenter_id"":""30"",""presenters_name"":""Joel Cochran"",""presenters_bio"":""Joel Cochran is a Manager Consultant with Sogeti, an international consulting firm.  He is a Microsoft Expression Blend MVP, an ASPInsider, and is currently serving as the INETA Mentor for Virginia. Joel is the author of \""Expression Blend in Action\"" and co-author of \""Windows 8 Apps with HTML5 and JavaScript\"", both by Manning Publications, as well as \""The Practical MVVM Manifesto\"" (http:\/\/practicalmvvm.com). A technology generalist, he works with technologies such as Windows 8, ASP.NET MVC4, SQL Server, SSIS, Azure, and much more. His languages of choice are C# and JavaScript. He spends an inordinate amount of time on Twitter (@joelcochran) and far less time on his blog http:\/\/joelcochran.com."",""presenters_twitter"":""joelcochran"",""presenters_blog"":""joelcochran.com"",""time_sort"":""1"",""room"":""Room 228""},{""id"":""50"",""time"":""9:15 - 10:15"",""title"":"".NET Reactive Extensions"",""track"":""Mobile, Object Oriented Languages"",""description"":""Demonstration of .NET's Rx (Reactive) extensions to simplify handling streams of event data from sensors, user input, etc."",""presenter_id"":""26"",""presenters_name"":""Jason Agostoni"",""presenters_bio"":""Jason has over 13 years of experience in software development, architecture and design in addition to several years of project management. Having worked for large, global manufacturing company, he has specialized skills in enterprise application design, development and management but also has equal experience in smaller business-oriented applications. In addition to software development experience, Jason has spent time developing content for and performing mentoring including SharePoint, BizTalk, TFS, Software Architecture, and general .NET. Additionally, Jason has deep experience in non-Microsoft platforms such as iOS development and PHP development."",""presenters_twitter"":""jagostoni"",""presenters_blog"":""jason.agostoni.net"",""time_sort"":""1"",""room"":""Ryan Room""},{""id"":""52"",""time"":""9:15 - 10:15"",""title"":""Better Features Through Backlog Grooming"",""track"":""Agile\/Process, Business of Software"",""description"":""The concept of GIGO (Garbage In, Garbage Out) is universal, and nowhere is it more prevalent than in software. Yet, software provides a fertile environment for the concept of VIVO (Value In, Value Out) to thrive. In this session, we'll explore techniques to deliver value through better grooming of inputs.<br \/>\r<br \/>\rSession Overview:<br \/>\r1. Definition of a strong story and acceptance criteria<br \/>\r2. Overview of backlog grooming & its role in Scrum<br \/>\r3. Hands on exercise to convert weak stories into strong ones via grooming session"",""presenter_id"":""46"",""presenters_name"":""Nivia Henry"",""presenters_bio"":""Curious human and woman in technology. Loves cats, Agile, Scrum, Lean, Kanban, Kaizen. LinkedIn profile: www.linkedin.com\/in\/nivia\/"",""presenters_twitter"":""Lanooba"",""presenters_blog"":"""",""time_sort"":""1"",""room"":""Room 308""},{""id"":""53"",""time"":""9:15 - 10:15"",""title"":""Building the Machine Society"",""track"":""Cloud, Functional Languages, Mobile"",""description"":""Using my qualifications as a distributed systems researcher, I will discuss how we can build a ubiquitous system to share computation and code among everybody in the world. In a nutshell, this is a system where all of our devices communicate by routing through each other (sometimes referred to as a mesh network.) They trade information about the world and about which pieces of code work best and the amount of trust they have about others in the world. Using this information, they can make very educated decisions to promote the best, most correct code for your system over time. They can also share computation and answers to computational problems with others. This is very much the next generation and one possible direction for the current \""cloud\"" infrastructures where control and power is distributed back to the hands of individual people.<br \/>\r<br \/>\rWith the goal being availability of code to every person on the planet, I will discuss the design, structure, and requirements most of which we already have developed. For instance, which network protocols we will use. What does the system model look like and how do people communicate? What might a typical device that we use look and act like?<br \/>\r<br \/>\rWhen the system is built, and to further the motivation, I will talk about the various benefits of such a system: a promotion of computation in the third world. This implies a further lowering of the barrier of entry to technology \/ making technology cheaper in both educational effort and monetary cost. Also, a novel approach to subverting censorship and central authority and governmental control over computation.<br \/>\r<br \/>\rNaturally, this system is not without fault or obstacle, so I also will spend time on the drawbacks or hurdles and ways to mitigate them: How do we trust others? How can we push this new model on a world that fears change? How do we make hardware cheap enough to distribute to lower wealth nations?"",""presenter_id"":""55"",""presenters_name"":""wilkie"",""presenters_bio"":""I am a published systems researcher and open source developer. I founded the XOmB kernel (http:\/\/xomb.org), the Djehuty operating system (http:\/\/djehuty.org,) and the http:\/\/rstat.us federated\/distributed microblogging platform. My goals with these projects are to connect people and give more power and control to those who are communicating."",""presenters_twitter"":""wilkieii"",""presenters_blog"":""blog.davewilkinsonii.com"",""time_sort"":""1"",""room"":""Room 310""},{""id"":""54"",""time"":""9:15 - 10:15"",""title"":""Entity Framework Code-First Migrations"",""track"":""Object Oriented Languages, Relational Database"",""description"":""Code First Migrations allow for database changes to be implemented all through code. Through the use of Package Manager Console, commands can be used to scaffold database changes.  This gives the developer complete control over database migrations within code files. In this presentation, we\u2019ll look at these PMC commands for generating code."",""presenter_id"":""51"",""presenters_name"":""Sam Nasr"",""presenters_bio"":""Sam Nasr has been a software developer since 1995, focusing mostly on Microsoft technologies. Having achieved multiple certifications from Microsoft (MCAD, MCTS(MOSS), and MCT), Sam develops, teaches, and tours the country to present various topics in .Net Framework. He is also actively involved with the Cleveland C#\/VB.Net User Group, where he has been the group leader since 2003. In addition, he also started the Cleveland WPF User Group, is the INETA Mentor for Ohio, and an author for Visual Studio Magazine. When not coding, Sam loves spending time with his family and friends or volunteering at his local church."",""presenters_twitter"":""SamNasr"",""presenters_blog"":""clevelanddotnet.blogspot.com\/"",""time_sort"":""1"",""room"":""Room 311""},{""id"":""55"",""time"":""9:15 - 10:15"",""title"":""Getting the Most Out of Your Page Objects"",""track"":""Testing"",""description"":""The Page Object Pattern is one of the foundational elements in building sustainable web UI tests.  This course will use Selenium Web Driver to explore the Page Object Pattern, talk about the reasons to use the pattern, look at ways to make implementations of the pattern better and examine anti-patterns around Page Objects so that we can identify areas of improvement in our code."",""presenter_id"":""31"",""presenters_name"":""Joel Mason"",""presenters_bio"":""I am an aspiring software craftsman currently working in the healthcare arena as a Software Developer IV at McKesson Automation. I also have had the opportunity to teach a hands-on Software Engineering course at Geneva College for the past several years.\r\rSome of my current technical interests include Behavior Driven Development, test automation and building distributed systems.  I also enjoy mentoring and working to improve team performance."",""presenters_twitter"":""jamason05"",""presenters_blog"":""www.craftoverart.com"",""time_sort"":""1"",""room"":""Room 314""},{""id"":""56"",""time"":""9:15 - 10:15"",""title"":""Messaging with RabbitMQ"",""track"":""NoSQL Database"",""description"":""This session will cover 3 main topics on Messaging and RabbitMQ.<br \/>\r- Quick introduction to what is messaging and advantages of using it. In this section I'll try to explain why using a NoSQL DB for queue is usually a bad idea.<br \/>\r- Introduction to RabbitMQ: How to start using it right way and why. I'll go through the main architectural designs of RabbitMQ and how to use it properly.<br \/>\r- Tips, tricks and lessons learned based on my experience with a production system using RabbitMQ at the core."",""presenter_id"":""19"",""presenters_name"":""Handerson Gomes"",""presenters_bio"":""I've been writing, testing and deploying software for the last 15 years, using a wide range of technologies and environments. I have been using RabbitMQ in the last year and would like to share some insights on why this is a great tool to have in our toolbox.\r\rI am a Distinguished Technical Consultant at Summa Technologies and a co-organizer of Pittsburgh Geek Out Days (http:\/\/www.pghgeekoutday.com\/)"",""presenters_twitter"":""handersongomes"",""presenters_blog"":""www.summa-tech.com\/blog\/"",""time_sort"":""1"",""room"":""Room 317""},{""id"":""49"",""time"":""9:15 - 10:15"",""title"":""SQL Server for the Accidental DBA"",""track"":""Relational Database"",""description"":""So the DBA quit and now you\u2019re stuck running the database server.  We will review the SQL Server stack for non-database professionals.  Also, a discussion of some of the most critical things that developers will need to know when managing a SQL Server where there is no professional DBA to be found. Some tips on how and where to reach out for help with problems and questions, and common gotchas and problems you may see in the field."",""presenter_id"":""13"",""presenters_name"":""Craig Purnell"",""presenters_bio"":""Craig Purnell is currently a Technical Instructor with New Horizons. Before joining New Horizons, he spent over 10 years as the Database Administrator at a large Midwestern law firm.  He has been in IT for 14 years and has spent his entire career working with enterprise databases and ERP systems. Craig is an active member of the Ohio North SQL Server User Group and has presented at many user groups, SQL Saturdays, and the PASS Summit in 2012"",""presenters_twitter"":""CraigPurnell"",""presenters_blog"":""www.craigpurnell.com"",""time_sort"":""1"",""room"":""Room 316""},{""id"":""57"",""time"":""9:15 - 10:15"",""title"":""Windows Phone 8 Development Success Tips"",""track"":""Mobile"",""description"":""\""This session is not your typical Microsoft \""\""You can do it in 20 minutes!\""\"" presentation. This is the story of Yinzlate for Windows Phone 8 and how it was a proven out and deployed to a developer device in 15 minutes but yet it took two months to ship it.<br \/>\r<br \/>\rThis session studies some of the crucial tips you need to consider when building Windows Phone apps. We'll cover some soft topics around design, user experience, and marketing as well as covering how all that soft stuff converts to code by seeing how Yinzlate did it.<br \/>\r<br \/>\rThis talk will cover topics like:<br \/>\r<br \/>\r- Use what the phone gives you: Find uses for the features and sensors that the Windows Phone 8 hardware provides you. Find out everything you ever wanted to know about the Windows Phone speech API.<br \/>\r<br \/>\r- Doing more with less: Find out how to make features \""\""fun\""\"" and give them an integrated feel even if they are very simple code tasks.<br \/>\r<br \/>\r- Respect your users: Learn about error handling in a way that makes your users appreciate your help rather than loathe your existence. Tips on how to think more about user experience and less about what's easy for you to code.<br \/>\r<br \/>\r- Market it: No, really. Market it, don't just tweet about it. Sure your app only costs $0.99 but you're never going to get that unless you market it like it's $99.00. We'll talk about tips on how to do that.<br \/>\r<br \/>\rLinks for the session:<br \/>\rhttp:\/\/yinzlate.com<br \/>\rhttp:\/\/bit.ly\/Yinzlate\"""",""presenter_id"":""54"",""presenters_name"":""Steven Hook"",""presenters_bio"":""Steven Hook is experienced in C#, JavaScript, ASP.NET MVC, Windows Phone, Windows Store Apps. In his six years of industry experience, he has built next generation solutions in sports using ASP.NET MVC and Silverlight for coaches, players, and officiating at the college and professional levels. Most recently, he is employed with Gateway Ticketing Systems bringing a fresh look into the ticketing industry by developing unique solutions to industry problems. He also develops applications for fun in the interest of solving real world problems.\r\rYou can read his blog at http:\/\/hookscode.com or follow him on Twitter @StevenHook."",""presenters_twitter"":""StevenHook"",""presenters_blog"":""hookscode.com"",""time_sort"":""1"",""room"":""Room 313""}]";
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
