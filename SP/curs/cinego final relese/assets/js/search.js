'use strict';

import { api_key, fetchDataFromServer } from "./api.js";
import { createMovieCard } from "./movie-card.js";


export function search() {

  const searchWrapper = document.querySelector("[search-wrapper]");
  const searchField = document.querySelector("[search-field]");

  const searchResultModal = document.createElement("div");
  searchResultModal.classList.add("search-modal");
  document.querySelector("main").appendChild(searchResultModal);

  let searchTimeout;

  searchField.addEventListener("input", function () {

    if (!searchField.value.trim()) {
      searchResultModal.classList.remove("active");
      searchWrapper.classList.remove("searching");
      clearTimeout(searchTimeout);
      return;
    }

    searchWrapper.classList.add("searching");
    clearTimeout(searchTimeout);

    searchTimeout = setTimeout(function () {

      fetchDataFromServer(`http://localhost:3000/movies?with_title=${searchField.value}&page=1`, function (movieList) {

        searchWrapper.classList.remove("searching");
        searchResultModal.classList.add("active");
        searchResultModal.innerHTML = ""; // remove old results

        searchResultModal.innerHTML = `
          <p class="label">Results for</p>
          
          <h1 class="heading">${searchField.value}</h1>
          
          <div class="movie-list">
            <div class="grid-list"></div>
          </div>
        `;

        for (const movie of movieList) {
          const movieCard = createMovieCard(movie);

          searchResultModal.querySelector(".grid-list").appendChild(movieCard);
        }

      });

    }, 500);

  });

}