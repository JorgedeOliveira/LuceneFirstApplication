using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneFirstApplication
{
    class LuceneTester
    {
        string indexDir = @"C:\Lucene\Index";
        string dataDir = @"C:\Lucene\Data";
        Searcher searcher;

        static void Main()  
        {
            LuceneTester tester;
            tester = new LuceneTester();
            tester.searchUsingFuzzyQuery("record3.txt");
        }

        public void searchUsingFuzzyQuery(string searchQuery)
        {
            var searcher = new Searcher(@"C:\Lucene\Data");

            Term term = new Term(LuceneConstants.FILE_NAME,searchQuery);

            Query query = new FuzzyQuery(term);

            TopDocs hits = searcher.search(query);

            foreach (ScoreDoc scoreDoc in hits.ScoreDocs)
            {
                Document doc = searcher.getDocument(scoreDoc);
                Console.WriteLine("Score: " + scoreDoc.Score + " ");
                Console.WriteLine("File: " + doc.Get(LuceneConstants.FILE_PATH));
            }
        }
    }
}
