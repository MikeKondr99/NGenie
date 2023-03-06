import { HttpClient } from '@angular/common/http';
import { MarkdownModule, MarkedOptions, MarkedRenderer } from 'ngx-markdown';

export function markedOptionsFactory(): MarkedOptions {
  const renderer = new MarkedRenderer();
  const base_renderer = new MarkedRenderer();


  // renderer.link = (href: string, title: string, text: string) => {
  //   if (text.startsWith("file:")) {
  //     console.log(text);
  //     let txt = text.substring(5)
  //     return `<p class="rounded-md bg-gray-50 h-16 flex flex-row items-center">
  //         <a href="${href}" class="no-underline"> 
  //           <img class="rounded-tl-md rounded-bl-md w-16 h-16 m-0" src="${href}" alt=" "/>
  //           <span href="${href}" class="ml-3 text-lg underline">${txt}</span>
  //         </a>
  //     </p>`;
  //   }
  //   else {
  //     return `<a href="${href}">${text}</a>`;
  //   }
  // }

  let shorts = new Map<string,string>([
    ["ps","powershell"],
    ["c#", "csharp"],
    ["rs", "rust"],
    ["c++","cpp"],

  ])

  renderer.code = (code: string, lang: string, isEscaped: boolean) => {
    let html = base_renderer.code(code,lang,isEscaped);
    console.log(html);
    let index = html.indexOf(`class="language-${lang}"`)
    let lang2 = lang;
    if(lang)
      lang2 = shorts.get(lang) ?? lang;
    html = [html.slice(0,index),html.slice(index + 17 + lang.length)].join(`class="language-${lang2}"`);
    console.log(html)
    return html;
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
