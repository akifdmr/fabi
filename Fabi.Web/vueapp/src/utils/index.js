import {validatePassword} from './passwordUtils.js'
import {containsDigit ,containsNonAlphanumeric ,containsUpperCase ,containsLowerCase, containsUniqueCharacters} from  './StringUtils.js';
import { hexToRGB,formatThousands,formatValue,tailwindConfig } from './Utils.js'

export const utilshelper ={
    validatePassword,
    containsDigit ,
    containsNonAlphanumeric ,
    containsUpperCase ,
    containsLowerCase,
    containsUniqueCharacters,
    hexToRGB,
    formatThousands,
    formatValue,
    tailwindConfig
};