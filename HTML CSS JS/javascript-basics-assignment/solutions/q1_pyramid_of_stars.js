/* Write a program to build a `Pyramid of stars` of given height */

const buildPyramid = (height) => {
    // Write your code here

    let result = '';
    if (!Number.isInteger(height) || height <= 0) {
        return '';
    }
    for (let i = 1; i <= height; i++) {
        let row = ' ';

        for (let j = height - i; j > 0; j--) {
            row += ' ';
        }

        // Add stars for the current level with spaces between them
        for (let k = 1; k <= i; k++) {
            if (k > 1) {
                row += ' ';
            }
            row += '*';
        }

        // Add newline character at the end of each row
        result += row + '  \n';
    }

    return result;
};

/* For example,
INPUT - buildPyramid(6)
OUTPUT -
     *
    * *
   * * *
  * * * *
 * * * * *
* * * * * *

*/

module.exports = buildPyramid;
