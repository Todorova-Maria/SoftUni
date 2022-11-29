import { render } from "./dom.js";

const section = document.getElementById('homeView');
section.remove();


export function showHome(ctx) {
   ctx.render(section);
}