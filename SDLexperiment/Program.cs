using System;
using SDL2;

// Projekt Setup Tipps (even though this is for core and mac)
// https://samulinatri.com/blog/net-core-sdl2-window-creation/

namespace SDLexperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            //IntPtr window;
            //IntPtr renderer;
            //SDL.SDL_CreateWindowAndRenderer(
            //    640,
            //    480,
            //    SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
            //    out window,
            //    out renderer
            //    );

            IntPtr window = SDL.SDL_CreateWindow("Fenstertitel",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                640,
                320,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

            IntPtr renderer = SDL.SDL_CreateRenderer(window, -1, 0);

            SDL.SDL_RenderSetScale(renderer, 10.0f, 10.0f); // Render a pixel 10 times bigger than it actually is


            SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
            for (int i = 0; i < 30; i++)
            {
                SDL.SDL_RenderDrawPoint(renderer, i, i);
            }
            SDL.SDL_RenderPresent(renderer);

            SDL.SDL_Delay(1500);
            SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_RenderPresent(renderer);


            // "Game Loop"
            SDL.SDL_Event e;
            bool quit = false;
            while (!quit)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            quit = true;
                            break;
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                            switch (e.key.keysym.sym)
                            {
                                case SDL.SDL_Keycode.SDLK_q:
                                    quit = true;
                                    break;
                            }
                            break;
                    }
                }
            }

            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();
        }
    }
}
