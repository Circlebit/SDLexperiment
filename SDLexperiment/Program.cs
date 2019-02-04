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

            //var window = IntPtr.Zero;
            //window = SDL.SDL_CreateWindow("Hallo Leute was geht ab :D",
            //    SDL.SDL_WINDOWPOS_CENTERED,
            //    SDL.SDL_WINDOWPOS_CENTERED,
            //    1028,
            //    800,
            //    SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            //    );

            IntPtr window;
            IntPtr renderer;
            SDL.SDL_CreateWindowAndRenderer(
                640,
                480,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
                out window,
                out renderer
                );

            IntPtr pixels;
            pixels = SDL.SDL_CreateTexture(renderer, SDL.SDL_PIXELFORMAT_ABGR8888, (int)SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STATIC, 640, 480);

            var test = pixels;

            SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
            for (int i = 0; i < 640; i++)
            {
                SDL.SDL_RenderDrawPoint(renderer, i, i);
            }
            SDL.SDL_RenderPresent(renderer);

            // SDL.SDL_Delay(5000);
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
