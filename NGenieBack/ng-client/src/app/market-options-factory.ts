import { HttpClient } from '@angular/common/http';
import { MarkdownModule, MarkedOptions, MarkedRenderer } from 'ngx-markdown';

export function markedOptionsFactory(): MarkedOptions {
  const renderer = new MarkedRenderer();


  renderer.link = (href: string,title: string, text:string) => {
    if(text.startsWith("file:")) {
      console.log(text);
      let txt = text.substring(5)
      return `<p class="outline outline-sky-200 rounded-md bg-sky-50 pl-5 py-3 mb-4">
          <a href="${href}" class="no-underline"> 
            <img class="w-8 h-8 m-0" src="https://cdn-icons-png.flaticon.com/512/1088/1088537.png"/>
          <span href="${href}" class="text-lg underline">${txt}</span>
          </a>
      </p>`;

    }
    else {
      return `<a href="${href}">${text}</a>`;
    }
  }



  return {
    renderer: renderer,
    gfm: true,
    breaks: false,
    pedantic: false,
    smartLists: true,
    smartypants: true,
    headerIds: true,
  };
}

// using specific option with FactoryProvider
