/* Write a Program to Flatten a given n-dimensional array */

const flatten = (arr) => {
    if (arr === null || arr === undefined || !Array.isArray(arr)) {
        return null;
    }
    const result = [];
	// Write your code here
	
    const flattenHelper = (inputArray) => {
        // Check if inputArray is an array before proceeding
        if (!Array.isArray(inputArray)) {
            throw new TypeError('Input is not an array');
        }

        inputArray.forEach((element) => {
            if (Array.isArray(element)) {
                // If the element is an array, recursively flatten it
                flattenHelper(element);
            } else {
                // If the element is not an array, push it to the result
                result.push(element);
            }
        });
};
try {
    // Initial call to flatten helper function
    flattenHelper(arr);
} catch (error) {
    if (error instanceof TypeError) {
        console.error('Caught an error during flattening:', error.message);
    } else {
        throw error;  // Re-throw if it's not a known error
    }
}

return result;
};

/* For example,
INPUT - flatten([1, [2, 3], [[4], [5]])
OUTPUT - [ 1, 2, 3, 4, 5 ]

*/

module.exports = flatten;
