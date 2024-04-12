'use strict';

const api_key = 'd53cd63350aa29d1b3f4dad57de14485';
const imageBaseURL = 'http://localhost:3000/image';

/**
 * fetch data from a server using the `url` and passes
 * the result in JSON data to a `callback` function,
 * along with an optional parameter if has `optionalParam`.
 */

const fetchDataFromServer = function (url, callback, optionalParam) {
  fetch(url)
    .then(response => response.json())
    .then(data => {
      callback(data, optionalParam);
    });
}

export { imageBaseURL, api_key, fetchDataFromServer };