﻿using System;
namespace webCrawler
{
    public class Constants
    {
        public const string json1 =
           @"{'pages':[
          {
             'address':'http://foo.bar.com/p1',
             'links':[
                'http://foo.bar.com/p2',
                'http://foo.bar.com/p3',
                'http://foo.bar.com/p4'
                  ] },
          {
             'address':'http://foo.bar.com/p2',
             'links':[
                'http://foo.bar.com/p2',
                'http://foo.bar.com/p4'
             ]
                         },
            {
                  'address':'http://foo.bar.com/p4',
                  'links':[
                     'http://foo.bar.com/p5',
                     'http://foo.bar.com/p1',
                     'http://foo.bar.com/p6'
                  ]
                  },
          {
             'address':'http://foo.bar.com/p5',
             'links':[
                  ] },
          {
             'address':'http://foo.bar.com/p6',
             'links':[
                'http://foo.bar.com/p7',
                'http://foo.bar.com/p4',
                'http://foo.bar.com/p5'
                  ] }
     
                  ]
                  }";
        public const string json2 = @"{'pages':[
           {
             'address':'http://foo.bar.com/p1',
             'links':[
                'http://foo.bar.com/p2'
             ]
           },
           {
           'address':'http://foo.bar.com/p2',
           'links':[
              'http://foo.bar.com/p3'
           ]
           },
           {
           'address':'http://foo.bar.com/p3',
           'links':[
              'http://foo.bar.com/p4'
           ]
           },
           {
           'address':'http://foo.bar.com/p4',
           'links':[
              'http://foo.bar.com/p5'
           ]
           },
           {
           'address':'http://foo.bar.com/p5',
           'links':[
              'http://foo.bar.com/p1'
           ]
           },
           {
           'address':'http://foo.bar.com/p6',
           'links':[
              'http://foo.bar.com/p1'
           ]
           }
           ]
           }";
        public const string resultsText = "Displaying Results For Internet ";
        public Constants()
        {
        }
    }
}
