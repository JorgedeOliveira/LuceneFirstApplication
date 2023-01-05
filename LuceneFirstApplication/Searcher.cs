using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;

namespace LuceneFirstApplication
{
    public class Searcher
    {
        const Lucene.Net.Util.Version AppLuceneVersion = Lucene.Net.Util.Version.LUCENE_30;

        IndexSearcher indexSearcher;
        QueryParser queryParser;
        Query query;


        public Searcher(string indexDirectoryPath)
        {
            Directory indexDirectory = FSDirectory.Open(indexDirectoryPath);
            var indexSearcher = new IndexSearcher(indexDirectory);
            queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, LuceneConstants.CONTENTS, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
        }

        public TopDocs search(string searchQuery)
        {
            var query = queryParser.Parse(searchQuery);
            return indexSearcher.Search(query, LuceneConstants.MAX_SEARCH);
        }

        public TopDocs search(Query query)
        {
            return indexSearcher.Search(query, LuceneConstants.MAX_SEARCH);
        }

        public Document getDocument(ScoreDoc scoreDoc)
        {
            return indexSearcher.Doc(scoreDoc.Doc);
        }

        public void close()
        {
            indexSearcher.Close();
        }
    }
}
