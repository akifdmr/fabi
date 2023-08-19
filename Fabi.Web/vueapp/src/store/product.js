import { defineStore } from 'pinia';

export const useProductStore = defineStore('product', {
    state: () => ({
        entity: {}
    }),
    getters: {
        getproduct: (state) => state.entity,
    },
    mutations: {
        setProducts(value) {
            this.entity = value;
        }
    },
    actions: {
        getProducts(id) {
            return null;
        }
    },
});

export default useProductStore;