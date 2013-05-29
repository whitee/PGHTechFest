using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PGHTechFest.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class About : PGHTechFest.Common.LayoutAwarePage
    {
        public About()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        

        public string Privacy
        {
            get { return (string)GetValue(PrivacyProperty); }
            set { SetValue(PrivacyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Privacy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrivacyProperty = 
            DependencyProperty.Register("Privacy", typeof(string), typeof(About), new PropertyMetadata(_TOC));



        const string _TOC =
        @"
        <h2>
	Application Terms and Conditions of Use
</h2>
<br/>

<h3>
	1. Terms
</h3>
<br/>
<p>
	By accessing this application, you are agreeing to be bound by these 
	application Terms and Conditions of Use, all applicable laws and regulations, 
	and agree that you are responsible for compliance with any applicable local 
	laws. If you do not agree with any of these terms, you are prohibited from 
	using or accessing this site. The materials contained in this application are 
	protected by applicable copyright and trade mark law.
</p>

<br/>
<h3>
	2. Use License
</h3>
<br/>

<ol type=""a"">
	<li>
		Permission is granted to temporarily download one copy of the materials 
		(information or software) on KindaSimple Solutions's application for personal, 
		non-commercial transitory viewing only. This is the grant of a license, 
		not a transfer of title, and under this license you may not:
		
		<ol type=""i"">
			<li>modify or copy the materials;</li>
			<li>use the materials for any commercial purpose, or for any public display (commercial or non-commercial);</li>
			<li>attempt to decompile or reverse engineer any software contained on KindaSimple Solutions's application;</li>
			<li>remove any copyright or other proprietary notations from the materials; or</li>
			<li>transfer the materials to another person or ""mirror"" the materials on any other server.</li>
		</ol>
	</li>
	<li>
		This license shall automatically terminate if you violate any of these restrictions and may be terminated by KindaSimple Solutions at any time. Upon terminating your viewing of these materials or upon the termination of this license, you must destroy any downloaded materials in your possession whether in electronic or printed format.
	</li>
</ol>

<br/>
<h3>
	3. Disclaimer
</h3>
<br/>

<ol type=""a"">
	<li>
		The materials on KindaSimple Solutions's application are provided ""as is"". KindaSimple Solutions makes no warranties, expressed or implied, and hereby disclaims and negates all other warranties, including without limitation, implied warranties or conditions of merchantability, fitness for a particular purpose, or non-infringement of intellectual property or other violation of rights. Further, KindaSimple Solutions does not warrant or make any representations concerning the accuracy, likely results, or reliability of the use of the materials on its Internet application or otherwise relating to such materials or on any sites linked to this site.
	</li>
</ol>

<br/>
<h3>
	4. Limitations
</h3>
<br/>

<p>
	In no event shall KindaSimple Solutions or its suppliers be liable for any damages (including, without limitation, damages for loss of data or profit, or due to business interruption,) arising out of the use or inability to use the materials on KindaSimple Solutions's Internet site, even if KindaSimple Solutions or a KindaSimple Solutions authorized representative has been notified orally or in writing of the possibility of such damage. Because some jurisdictions do not allow limitations on implied warranties, or limitations of liability for consequential or incidental damages, these limitations may not apply to you.
</p>
			
<br/>
<h3>
	5. Revisions and Errata
</h3>
<br/>

<p>
	The materials appearing on KindaSimple Solutions's application could include technical, typographical, or photographic errors. KindaSimple Solutions does not warrant that any of the materials on its application are accurate, complete, or current. KindaSimple Solutions may make changes to the materials contained on its application at any time without notice. KindaSimple Solutions does not, however, make any commitment to update the materials.
</p>

<br/>
<h3>
	6. Links
</h3>
<br/>

<p>
	KindaSimple Solutions has not reviewed all of the sites linked to its Internet application and is not responsible for the contents of any such linked site. The inclusion of any link does not imply endorsement by KindaSimple Solutions of the site. Use of any such linked application is at the user's own risk.
</p>

<br/>
<h3>
	7. Site Terms of Use Modifications
</h3>
<br/>

<p>
	KindaSimple Solutions may revise these terms of use for its application at any time without notice. By using this application you are agreeing to be bound by the then current version of these Terms and Conditions of Use.
</p>

<br/>
<h3>
	8. Governing Law
</h3>
<br/>

<p>
	Any claim relating to KindaSimple Solutions's application shall be governed by the laws of the State of New York without regard to its conflict of law provisions.
</p>

<p>
	General Terms and Conditions applicable to Use of a Application.
</p>
<br/>
<h2>
	Privacy Policy
</h2>
<br/>

<p>
	Your privacy is very important to us. Accordingly, we have developed this Policy in order for you to understand how we collect, use, communicate and disclose and make use of personal information. The following outlines our privacy policy.
</p>

<br/>
<ul>
	<li>
		Before or at the time of collecting personal information, we will identify the purposes for which information is being collected.
	</li>
	<li>
		We will collect and use of personal information solely with the objective of fulfilling those purposes specified by us and for other compatible purposes, unless we obtain the consent of the individual concerned or as required by law.		
	</li>
	<li>
		We will only retain personal information as long as necessary for the fulfillment of those purposes. 
	</li>
	<li>
		We will collect personal information by lawful and fair means and, where appropriate, with the knowledge or consent of the individual concerned. 
	</li>
	<li>
		Personal data should be relevant to the purposes for which it is to be used, and, to the extent necessary for those purposes, should be accurate, complete, and up-to-date. 
	</li>
	<li>
		We will protect personal information by reasonable security safeguards against loss or theft, as well as unauthorized access, disclosure, copying, use or modification.
	</li>
	<li>
		We will make readily available to customers information about our policies and practices relating to the management of personal information. 
	</li>
</ul>

<p>
	We are committed to conducting our business in accordance with these principles in order to ensure that the confidentiality of personal information is protected and maintained. 
</p>";
    }
}
