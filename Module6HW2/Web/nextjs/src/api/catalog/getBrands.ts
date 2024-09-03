import {CatalogBrand} from "../../config/types/catalog/catalogBrand";

export const getBrands = async (): Promise<CatalogBrand[] | null> => {
    try {
        const response = await fetch("http://www.alevelwebsite.com:5001/api/v1/CatalogBff/Brands", {
            cache: 'force-cache',
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            }
        });

        if (!response.ok) {
            console.error("Error during request:", response.statusText);
            return null;
        }

        return await response.json();
    } catch (error) {
        throw new Error("Failed to load products")
    }
};