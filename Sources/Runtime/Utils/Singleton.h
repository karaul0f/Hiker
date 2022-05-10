#pragma once
template <typename Type>
class Singleton
{
public:
    static Type& Instance()
    {
        static Type instance;
        return instance;
    }

protected:
    Singleton() = default;
    Singleton(const Singleton&) = delete;
    Singleton(Singleton&&) noexcept = delete;
    Singleton& operator=(const Singleton&) = delete;
    Singleton& operator=(Singleton&&) noexcept = delete;
    ~Singleton() = default;
};
