/* Write a Program to convert an array of objects to an object
	based on a given key */


    const convert = (array, key) => {
        // Write your code here
        if (!Array.isArray(array) || typeof key !== 'string') {
            return null;
        }
        const result = {};
        
        array.forEach(item => {
            const keyValue = item[key];
            result[keyValue] = item;
        });
        
        return result;
    
    };
    
    /* For example,
    INPUT - convert([{id: 1, value: 'abc'}, {id: 2, value: 'xyz'}], 'id')
    OUTPUT - {
                '1': {id: 1, value: 'abc'},
                '2': {id: 2, value: 'xyz'}
             }
    
    
    */
    
    module.exports = convert;
    