import { HttpClient } from '@angular/common/http';
import { MarkdownModule, MarkedOptions, MarkedRenderer } from 'ngx-markdown';

export function markedOptionsFactory(): MarkedOptions {
  const renderer = new MarkedRenderer();


  renderer.link = (href: string,title: string, text:string) => {
    if(text.startsWith("file:")) {
      console.log(text);
      let txt = text.substring(5)
      return `<p class="rounded-md bg-gray-50 h-16 flex flex-row items-center">
          <a href="${href}" class="no-underline"> 
            <img class="rounded-tl-md rounded-bl-md w-16 h-16 m-0" src="${href}" alt=" "/>
            <span href="${href}" class="ml-3 text-lg underline">${txt}</span>
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
