'use strict';

/**
 * import all components and functions
 */

import { sidebar } from "./sidebar.js";
import { api_key, imageBaseURL, fetchDataFromServer } from "./api.js";
import { createMovieCard } from "./movie-card.js";
import { search } from "./search.js";

const pageContent = document.querySelector("[page-content]");

sidebar();

const homePageSections = [
  {
    title: "New Movies",
    path: "/movies/new"
  },
  {
    title: "Top Rated Movies",
    path: "/movies/popular?page=2"
  }
]

fetchDataFromServer(`http://localhost:3000/movies/popular?page=1`, function (movieList) {
  const banner = document.createElement("section");
  banner.classList.add("banner");
  banner.ariaLabel = "Popular Movies";

  banner.innerHTML = `
    <div class="banner-slider"></div>
    
    <div class="slider-control">
      <div class="control-inner"></div>
    </div>
  `;

  let controlItemIndex = 0;

  for (const [index, movie] of movieList.entries()) {

    const {
      img_path,
      title,
      release_date,
      overview,
      vote_average,
      id
    } = movie;

    const sliderItem = document.createElement("div");
    sliderItem.classList.add("slider-item");
    sliderItem.setAttribute("slider-item", "");

    sliderItem.innerHTML = `
      <img src="${imageBaseURL}${img_path}" alt="${title}" class="img-cover" loading=${index === 0 ? "eager" : "lazy"
      }>
      
      <div class="banner-content">
      
        <h2 class="heading">${title}</h2>
      
        <div class="meta-list">
          <div class="meta-item">${release_date?.split("-")[0] ?? "Not Released"}</div>
      
          <div class="meta-item card-badge">${vote_average}</div>
        </div>
      
        <p class="banner-text">${overview}</p>
      
        <a href="./detail.html" class="btn" onclick="getMovieDetail(${id})">
          <img src="./assets/images/play_circle.png" width="24" height="24" aria-hidden="true" alt="play circle">
      
          <span class="span">Watch Now</span>
        </a>
      
      </div>
    `;
    banner.querySelector(".banner-slider").appendChild(sliderItem);


    const controlItem = document.createElement("button");
    controlItem.classList.add("poster-box", "slider-item");
    controlItem.setAttribute("slider-control", `${controlItemIndex}`);

    controlItemIndex++;

    controlItem.innerHTML = `
      <img src="${imageBaseURL}${img_path}" alt="Slide to ${title}" loading="lazy" draggable="false" class="img-cover">
    `;
    banner.querySelector(".control-inner").appendChild(controlItem);

  }

  pageContent.appendChild(banner);

  addHeroSlide();


  /**
   * fetch data for home page sections (top rated, upcoming, trending)
   */
  for (const { title, path } of homePageSections) {
    fetchDataFromServer(`http://localhost:3000${path}`, createMovieList, title);
  }

});



/**
 * Hero slider functionality
 */

const addHeroSlide = function () {

  const sliderItems = document.querySelectorAll("[slider-item]");
  const sliderControls = document.querySelectorAll("[slider-control]");

  let lastSliderItem = sliderItems[0];
  let lastSliderControl = sliderControls[0];

  lastSliderItem.classList.add("active");
  lastSliderControl.classList.add("active");

  const sliderStart = function () {
    lastSliderItem.classList.remove("active");
    lastSliderControl.classList.remove("active");

    // `this` == slider-control
    sliderItems[Number(this.getAttribute("slider-control"))].classList.add("active");
    this.classList.add("active");

    lastSliderItem = sliderItems[Number(this.getAttribute("slider-control"))];
    lastSliderControl = this;
  }

  addEventOnElements(sliderControls, "click", sliderStart);

}


const createMovieList = function (movieList, title) {
  const movieListElem = document.createElement("section");
  movieListElem.classList.add("movie-list");
  movieListElem.ariaLabel = `${title}`;

  movieListElem.innerHTML = `
    <div class="title-wrapper">
      <h3 class="title-large">${title}</h3>
    </div>
    
    <div class="slider-list">
      <div class="slider-inner"></div>
    </div>
  `;

  for (const movie of movieList) {
    const movieCard = createMovieCard(movie); // called from movie_card.js

    movieListElem.querySelector(".slider-inner").appendChild(movieCard);
  }

  pageContent.appendChild(movieListElem);

}



search();