(()=>{"use strict";var e,t,r,o,n,a={},i={};function u(e){var t=i[e];if(void 0!==t)return t.exports;var r=i[e]={exports:{}};return a[e].call(r.exports,r,r.exports,u),r.exports}u.m=a,e=[],u.O=(t,r,o,n)=>{if(!r){var a=1/0;for(l=0;l<e.length;l++){r=e[l][0],o=e[l][1],n=e[l][2];for(var i=!0,f=0;f<r.length;f++)(!1&n||a>=n)&&Object.keys(u.O).every((e=>u.O[e](r[f])))?r.splice(f--,1):(i=!1,n<a&&(a=n));if(i){e.splice(l--,1);var d=o();void 0!==d&&(t=d)}}return t}n=n||0;for(var l=e.length;l>0&&e[l-1][2]>n;l--)e[l]=e[l-1];e[l]=[r,o,n]},u.n=e=>{var t=e&&e.__esModule?()=>e.default:()=>e;return u.d(t,{a:t}),t},r=Object.getPrototypeOf?e=>Object.getPrototypeOf(e):e=>e.__proto__,u.t=function(e,o){if(1&o&&(e=this(e)),8&o)return e;if("object"==typeof e&&e){if(4&o&&e.__esModule)return e;if(16&o&&"function"==typeof e.then)return e}var n=Object.create(null);u.r(n);var a={};t=t||[null,r({}),r([]),r(r)];for(var i=2&o&&e;"object"==typeof i&&!~t.indexOf(i);i=r(i))Object.getOwnPropertyNames(i).forEach((t=>a[t]=()=>e[t]));return a.default=()=>e,u.d(n,a),n},u.d=(e,t)=>{for(var r in t)u.o(t,r)&&!u.o(e,r)&&Object.defineProperty(e,r,{enumerable:!0,get:t[r]})},u.f={},u.e=e=>Promise.all(Object.keys(u.f).reduce(((t,r)=>(u.f[r](e,t),t)),[])),u.u=e=>"assets/js/"+({53:"935f2afb",162:"d589d3a7",274:"ad1b6677",514:"1be78505",918:"17896441"}[e]||e)+"."+{53:"6cc701aa",162:"6a800bd9",274:"5f440a5e",514:"3a6c2139",918:"7d307439",972:"d5cc17b1"}[e]+".js",u.miniCssF=e=>{},u.g=function(){if("object"==typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(e){if("object"==typeof window)return window}}(),u.o=(e,t)=>Object.prototype.hasOwnProperty.call(e,t),o={},n="docs:",u.l=(e,t,r,a)=>{if(o[e])o[e].push(t);else{var i,f;if(void 0!==r)for(var d=document.getElementsByTagName("script"),l=0;l<d.length;l++){var s=d[l];if(s.getAttribute("src")==e||s.getAttribute("data-webpack")==n+r){i=s;break}}i||(f=!0,(i=document.createElement("script")).charset="utf-8",i.timeout=120,u.nc&&i.setAttribute("nonce",u.nc),i.setAttribute("data-webpack",n+r),i.src=e),o[e]=[t];var c=(t,r)=>{i.onerror=i.onload=null,clearTimeout(p);var n=o[e];if(delete o[e],i.parentNode&&i.parentNode.removeChild(i),n&&n.forEach((e=>e(r))),t)return t(r)},p=setTimeout(c.bind(null,void 0,{type:"timeout",target:i}),12e4);i.onerror=c.bind(null,i.onerror),i.onload=c.bind(null,i.onload),f&&document.head.appendChild(i)}},u.r=e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},u.p="/tokens/",u.gca=function(e){return e={17896441:"918","935f2afb":"53",d589d3a7:"162",ad1b6677:"274","1be78505":"514"}[e]||e,u.p+u.u(e)},(()=>{var e={303:0,532:0};u.f.j=(t,r)=>{var o=u.o(e,t)?e[t]:void 0;if(0!==o)if(o)r.push(o[2]);else if(/^(303|532)$/.test(t))e[t]=0;else{var n=new Promise(((r,n)=>o=e[t]=[r,n]));r.push(o[2]=n);var a=u.p+u.u(t),i=new Error;u.l(a,(r=>{if(u.o(e,t)&&(0!==(o=e[t])&&(e[t]=void 0),o)){var n=r&&("load"===r.type?"missing":r.type),a=r&&r.target&&r.target.src;i.message="Loading chunk "+t+" failed.\n("+n+": "+a+")",i.name="ChunkLoadError",i.type=n,i.request=a,o[1](i)}}),"chunk-"+t,t)}},u.O.j=t=>0===e[t];var t=(t,r)=>{var o,n,a=r[0],i=r[1],f=r[2],d=0;if(a.some((t=>0!==e[t]))){for(o in i)u.o(i,o)&&(u.m[o]=i[o]);if(f)var l=f(u)}for(t&&t(r);d<a.length;d++)n=a[d],u.o(e,n)&&e[n]&&e[n][0](),e[n]=0;return u.O(l)},r=self.webpackChunkdocs=self.webpackChunkdocs||[];r.forEach(t.bind(null,0)),r.push=t.bind(null,r.push.bind(r))})()})();