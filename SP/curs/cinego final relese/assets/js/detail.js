'use strict';

import { api_key, imageBaseURL, fetchDataFromServer } from "./api.js";
import { sidebar } from "./sidebar.js";
import { createMovieCard } from "./movie-card.js";
import { search } from "./search.js";

const movieId = window.localStorage.getItem("movieId");
const pageContent = document.querySelector("[page-content]");
const urlParam = window.localStorage.getItem("urlParam");

sidebar();

fetchDataFromServer(`http://localhost:3000/movie/${movieId}`, function (data) {
  const {
    img_path,
    title,
    release_date,
    runtime,
    vote_average,
    certification,
    overview,
    actors,
    director,
    video_url,
  } = data['movie']

  const genres = data['genres'];


  document.title = `${title} - Cinego`;

  const movieDetail = document.createElement("div");
  movieDetail.classList.add("movie-detail");

  movieDetail.innerHTML = `
    <div class="backdrop-image" style="background-image: url('${imageBaseURL}${"w1280" || "original"}${img_path}')"></div>
    
    <figure class="poster-box movie-poster">
      <img src="${imageBaseURL}${img_path}" alt="${title} poster" class="img-cover">
    </figure>
    
    <div class="detail-box">
    
      <div class="detail-content">
        <h1 class="heading">${title}</h1>
    
        <div class="meta-list">
    
          <div class="meta-item">
            <img src="./assets/images/star.png" width="20" height="20" alt="rating">
    
            <span class="span">${vote_average}</span>
          </div>
    
          <div class="separator"></div>
    
          <div class="meta-item">${runtime}m</div>
    
          <div class="separator"></div>
    
          <div class="meta-item">${release_date?.split("-")[0] ?? "Not Released"}</div>
    
          <div class="meta-item card-badge">${certification}</div>
    
        </div>
    
        <p class="genre">${genres.join(", ")}</p>
    
        <p class="overview">${overview}</p>
    
        <ul class="detail-list">
    
          <div class="list-item">
            <p class="list-name">Starring</p>
    
            <p>${actors}</p>
          </div>
    
          <div class="list-item">
            <p class="list-name">Directed By</p>
    
            <p>${director}</p>
          </div>
    
        </ul>
    
      </div>
    
      <div class="title-wrapper">
        <h3 class="title-large">Trailers and Clips</h3>
      </div>
    
      <div class="slider-list">
        <div class="slider-inner"></div>
      </div>
    
    </div>
  `;

  const videoCard = document.createElement("div");
  videoCard.classList.add("video-card");

  videoCard.innerHTML = `
      <iframe width="500" height="294" src="${video_url}"
        frameborder="0" allowfullscreen="1" class="img-cover" loading="lazy"></iframe>
    `;

  movieDetail.querySelector(".slider-inner").appendChild(videoCard);

  pageContent.appendChild(movieDetail);

  fetchDataFromServer(`http://localhost:3000/movies?page=1&${urlParam}`, addSuggestedMovies);

});



const addSuggestedMovies = function (movieList) {
  const movieListElem = document.createElement("section");
  movieListElem.classList.add("movie-list");
  movieListElem.ariaLabel = "You May Also Like";

  movieListElem.innerHTML = `
    <div class="title-wrapper">
      <h3 class="title-large">You May Also Like</h3>
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