import { defineConfig } from "vite";
import rollupPluginGas from "rollup-plugin-google-apps-script";

export default defineConfig({
    plugins: [
        rollupPluginGas()
    ],
    build: {
        rollupOptions: {
            input: "./out/Program.js",
            output: {
                dir: "./dist",
                entryFileNames: "[name].js",
            },
        },
        minify: false,
    },
})
