'use strict';

import { api_key, fetchDataFromServer } from "./api.js";
import { sidebar } from "./sidebar.js";
import { createMovieCard } from "./movie-card.js";
import { search } from "./search.js";

// collectc genre name & url parameter from local storage
const genreName = window.localStorage.getItem("genreName");
const urlParam = window.localStorage.getItem("urlParam");

const pageContent = document.querySelector("[page-content]");



sidebar();



let currentPage = 1;
let totalPages = 1;

fetchDataFromServer(`http://localhost:3000/movies?page=${currentPage}&${urlParam}`, function (movieList) {
  document.title = `${genreName} Movies - Cinego`;
  totalPages = movieList.length < 20 ? 0 : 1;

  const movieListElem = document.createElement("section");
  movieListElem.classList.add("movie-list", "genre-list");
  movieListElem.ariaLabel = `${genreName} Movies`;

  movieListElem.innerHTML = `
    <div class="title-wrapper">
      <h1 class="heading">All ${genreName} Movies</h1>
    </div>
    
    <div class="grid-list"></div>
    
    <button class="btn load-more" load-more>Load More</button>
  `;


  /**
   * add movie card based on fetched item
   */
  for (const movie of movieList) {
    const movieCard = createMovieCard(movie);

    movieListElem.querySelector(".grid-list").appendChild(movieCard);
  }

  pageContent.appendChild(movieListElem);


  if (totalPages == 0) document.querySelector("[load-more]").style.display = "none";

  /**
   * load more button functionality
   */
  document.querySelector("[load-more]").addEventListener("click", function () {

    if (currentPage >= totalPages) {
      this.style.display = "none"; // this == loading-btn
      return;
    }

    currentPage++;
    this.classList.add("loading"); // this == loading-btn

    fetchDataFromServer(`http://localhost:3000/movies?page=${currentPage}&${urlParam}`, (movieList) => {
      this.classList.remove("loading"); // this == loading-btn
      totalPages = movieList.length < 20 ? 0 : totalPages++;

      for (const movie of movieList) {
        const movieCard = createMovieCard(movie);

        movieListElem.querySelector(".grid-list").appendChild(movieCard);
      }
    });

  });

});



search();