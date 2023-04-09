"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[761],{3905:(e,t,n)=>{n.d(t,{Zo:()=>s,kt:()=>f});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var l=r.createContext({}),p=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},s=function(e){var t=p(e.components);return r.createElement(l.Provider,{value:t},e.children)},d="mdxType",u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},m=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,l=e.parentName,s=c(e,["components","mdxType","originalType","parentName"]),d=p(n),m=o,f=d["".concat(l,".").concat(m)]||d[m]||u[m]||i;return n?r.createElement(f,a(a({ref:t},s),{},{components:n})):r.createElement(f,a({ref:t},s))}));function f(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=m;var c={};for(var l in t)hasOwnProperty.call(t,l)&&(c[l]=t[l]);c.originalType=e,c[d]="string"==typeof e?e:o,a[1]=c;for(var p=2;p<i;p++)a[p]=n[p];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}m.displayName="MDXCreateElement"},5e3:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>l,contentTitle:()=>a,default:()=>u,frontMatter:()=>i,metadata:()=>c,toc:()=>p});var r=n(7462),o=(n(7294),n(3905));const i={sidebar_position:3},a="Handling Exceptions",c={unversionedId:"handling-exceptions",id:"handling-exceptions",title:"Handling Exceptions",description:"Coded exception middleware would handle all exceptions which appear in request pipeline, log it and send coded exception in HTTP response.",source:"@site/docs/handling-exceptions.md",sourceDirName:".",slug:"/handling-exceptions",permalink:"/tokens/docs/handling-exceptions",draft:!1,editUrl:"https://github.com/webinex/asky/tree/main/docs/docs/handling-exceptions.md",tags:[],version:"current",sidebarPosition:3,frontMatter:{sidebar_position:3},sidebar:"tutorialSidebar",previous:{title:"Built in Codes",permalink:"/tokens/docs/built-in-codes"},next:{title:"Usage with HttpClient",permalink:"/tokens/docs/usage-with-httpclient"}},l={},p=[],s={toc:p},d="wrapper";function u(e){let{components:t,...n}=e;return(0,o.kt)(d,(0,r.Z)({},s,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"handling-exceptions"},"Handling Exceptions"),(0,o.kt)("p",null,"Coded exception middleware would handle all exceptions which appear in request pipeline, log it and send coded exception in HTTP response."),(0,o.kt)("p",null,"Out of the box, coded exception middleware would convert all exceptions except ",(0,o.kt)("inlineCode",{parentName:"p"},"CodedException")," to ",(0,o.kt)("inlineCode",{parentName:"p"},"HttpStatusCode.Unexpected"),". But you can add exception convertion:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="ExceptionConverter.cs"',title:'"ExceptionConverter.cs"'},'public class ExceptionConverter : ICodedFailureConverter\n{\n    public ConvertResult Convert(Exception ex)\n    {\n        return ex switch\n        {\n            UnauthorizedAccessException _ => ConvertResult.Success(CodedFailure.Unauthorized()),\n            NotUniqueEmailException exc => ConvertResult.Success(new CodedFailure("INV.NOT_UNIQUE_EMAIL", new { exc.Email })),\n            _ => ConvertResult.Nope(),\n        };\n    }\n}\n')),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="Startup.cs"',title:'"Startup.cs"'},"services\n  .AddCodedFailures(x => x\n      .AddFirst<ExceptionConverter>())\n")))}u.isMDXComponent=!0}}]);